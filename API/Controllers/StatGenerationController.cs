using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DnD_API_Adapter;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel;
using Service.CharacterGeneration;

namespace API.Controllers
{
    [Route("api/generate")]
    public class StatGenerationController : ControllerBase
	{

		[HttpPost]
        public async Task<IActionResult> Generate([FromBody] GenerationParameters param)
		{
			if (param.DiceNames.Length < 1)
			{
				return StatusCode(422, "No dicenames were given");
			}
			List<Die> dice = new List<Die>();
			foreach (var name in param.DiceNames)
			{
				foreach(var die in Die.all)
				{
                    if (die.Name.Equals(name))
					{
						dice.Add(die);
					}
                }
			}

			if (dice.Count < 1)
			{
				return NotFound("Given dice type(s) doesn't exist");
			}
			var service = new GenerationService(new DNDClient(), new DiceSimulator(dice.ToArray()));
			var res = await service.Generate(param.RaceIndex);
			if (res == null)
			{
				return NotFound("Given race was not found");
			}
			return Ok(res);
		}
	}
}

