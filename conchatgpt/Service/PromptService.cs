/*using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3;
*/
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Managers;
using OpenAI;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace conchatgpt.Service
{
    public class PromptService : Iservice
    {
        private string _apiKey = "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";

        private string _init = "tengo una base de datos de usuarios, puedes darme una";

        public async Task<string> Get(string prompt)
        {
            string SQL = "";

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = _apiKey
            });

            var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest()
            {
                Messages = new List<ChatMessage>
        {
            ChatMessage.FromUser(_init + prompt)
        },
                Model = OpenAI.ObjectModels.Models.ChatGpt3_5Turbo
            });

            if (completionResult.Successful)
            {
                var response = completionResult.Choices.First().Message.Content;

                // Buscar la posición de "SELECT" en la respuesta
                int selectIndex = response.IndexOf("SELECT");

                if (selectIndex != -1)
                {
                    // Si "SELECT" fue encontrado, extraer la consulta SQL a partir de esa posición
                    SQL = response.Substring(selectIndex);
                }
                else
                {
                    // Si "SELECT" no fue encontrado, puedes manejarlo de la manera que prefieras.
                    // Por ejemplo, podrías devolver un mensaje de error o una consulta SQL predeterminada.
                    SQL = "SELECT * FROM DataCiudad"; // Reemplaza "TableName" con el nombre de tu tabla
                }
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknow Error");
                }
            }

            return SQL;
        }


        /*public async Task<string> Get(string prompt)
        {
            string SQL = "";

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = _apiKey
            });

            var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest()
            {
                Messages = new List<ChatMessage>
                {
                    ChatMessage.FromUser(_init+prompt)
                },
                Model=OpenAI.GPT3.ObjectModels.Models.ChatGpt3_5Turbo
            });

            if (completionResult.Successful)
            {
                var response = completionResult.Choices.First().Message.Content;
                SQL = response.Substring(response.IndexOf("SELECT"));//usamos el indexparar evitar el problema de seleccion :/
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknow Error");
                }

            }

            return SQL;
            
        }*/
    }
}

