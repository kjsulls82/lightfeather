using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebServer.Models;

namespace WebServer.Controllers
{
    [ApiController]    
    public class ShiftCipherController : ControllerBase
    {       
        private static ILogger<ShiftCipherController> _logger;
        private static readonly string _basePath = @"c:\temp";
        private static readonly string _fileName = "encodedMessage.txt";

        public ShiftCipherController(ILogger<ShiftCipherController> logger)
        {
            _logger = logger;
        }

        [HttpPost("api/encode")]
        public async Task<IActionResult> Encode(Payload payload)
        {
            var result = await Task.Run(async () =>
            {
                try
                {
                    if (payload == null || string.IsNullOrWhiteSpace(payload.Message))
                        return Ok(new Result { EncodedMessage = string.Empty });

                    var message = Encipher(payload.Shift, payload.Message);                   
                    await Save(message);
                    return Ok(new Result { EncodedMessage = message });
                }
                catch (Exception ex)
                {
                    _logger.LogError("ShiftCipherController.encode", ex);
                    return StatusCode(StatusCodes.Status500InternalServerError, new Result { EncodedMessage = string.Empty });
                }
            });

            return result;
        }

        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        
        private static string Encipher(int key, string input)
        {
            var sb = new StringBuilder();

            foreach (char ch in input)
            {
                sb.Append(Cipher(ch, key));
            }                

            return sb.ToString();
        }

        private static async Task Save(string message)
        {
            Directory.CreateDirectory(_basePath);

            using (var writer = new StreamWriter($"{_basePath }/{_fileName}"))
            {
                await writer.WriteLineAsync(message);
            }
        }
    }     
}
