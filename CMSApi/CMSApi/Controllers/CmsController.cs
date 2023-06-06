using System.Text.Json;
using CMSApi.Models;
using CMSApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;


namespace CMSApi.Controllers
{
    [Route("api/[controller]")]
    public class CmsController : ControllerBase
    {
        private readonly CMSService _cmsService;

        public CmsController(CMSService cmsService) =>
            _cmsService = cmsService;

        
        [HttpGet]
        public async Task<List<Client>> Get() =>
        await _cmsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            var client = await _cmsService.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpGet("{id:length(24)}/{documentName}")]
        public async Task<ActionResult<object>> Get(string id, string documentName)
        {
            var client = await _cmsService.GetSectionAsync(id, documentName);

            if (client is null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client newClient)
        {
            await _cmsService.CreateAsync(newClient);

            return CreatedAtAction(nameof(Get), new { id = newClient.Id }, newClient);
        }

       

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Client updatedClient)
        {
            var client = await _cmsService.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            updatedClient.Id = client.Id;

            await _cmsService.UpdateAsync(id, updatedClient);

            return NoContent();
        }



        [HttpPut("{id:length(24)}/{documentName}/{fieldName}")]
        public async Task<IActionResult> UpdateSpecificField(string id, string documentName, string fieldName, [FromBody] Dictionary<string, string> newValues)
        {
            var client = await _cmsService.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            await _cmsService.UpdateSpecificFieldAsync(id, documentName, fieldName, newValues);

            return NoContent();
        }

        [HttpPatch("{id:length(24)}/{documentName}/{fieldName}")]
        public async Task<IActionResult> UpdateSpecificField(string id, string documentName, string fieldName, [FromBody] JsonElement newValue)
        {
            Console.WriteLine(newValue);
            BsonValue bsonValue;
            try
            {
                bsonValue = BsonDocument.Parse(newValue.GetRawText());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                await _cmsService.PatchFieldAsync(id, documentName, fieldName, bsonValue);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            // (HTTP 204)
            return NoContent();
        }

        [HttpDelete("{id:length(24)}/{documentName}/{fieldName}")]
        public async Task<IActionResult> DeleteField(string id, string documentName, string fieldName)
        {
            var client = await _cmsService.GetAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            await _cmsService.DeleteFieldAsync(id, documentName, fieldName);

            return NoContent();
        }




    }
}

