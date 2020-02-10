using System;
using System.Collections.Generic;
using System.Text.Json;
using VocabulatorLibrary.Data;

namespace VocabulatorWeb.Serializers
{
    public class ResponseSerializer : ISerializer
    {
        public string Serialize(IEnumerable<IDto> dtoCollection)
        {
            if (dtoCollection == null) throw new ArgumentNullException(nameof(dtoCollection));

            var jsonObject = string.Empty;

            foreach (var dto in dtoCollection)
            {
                switch (dto)
                {
                    case WordDto wordDto:
                        jsonObject += JsonSerializer.Serialize(wordDto);
                        break;
                    case ErrorDto errorDto:
                        jsonObject += JsonSerializer.Serialize(errorDto);
                        break;
                }

                jsonObject += ",";
            }

            jsonObject = jsonObject.TrimEnd(',');
            return $"[{jsonObject}]";
        }
    }
}