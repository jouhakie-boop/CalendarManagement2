using CalendarManagementAPI.Server.Models;
using CalendarManagementAppService;
using CalendarManagementModels;
using Intercom.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalendarManagementAPI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly CalendarAppService appService;

        public CalendarController()
        {
            appService = new CalendarAppService();
        }

        [HttpGet("{name}")]
        public ActionResult<Reminder> ViewReminder(string name)
        {
            var reminder = appService.ViewReminder(name);

            if (reminder == null)
                return NotFound();

            return Ok(reminder);
        }

        [HttpGet]
        public ActionResult<Reminder> ViewAllReminders()
        {
            var reminder = appService.ViewAllReminders();
            return Ok(reminder);
        }

        [HttpPost]
        public IActionResult CreateReminder([FromBody] ReminderViewModel reminder)
        {
            if (reminder == null)
            {
                return BadRequest("Reminder data is required");
            }

            var newReminder = new Reminder
            {
                Name = reminder.Name,
                Date = reminder.Date,
                Day = reminder.Day,
                Time = reminder.Time
            };

            var created = appService.CreateReminder(newReminder);

            if (!created)
            {
                return Conflict("Reminder could not be created.");
            }

            return CreatedAtAction(
                nameof(ViewReminder),
                new { name = newReminder.Name },
                newReminder
            );
        }


        [HttpPatch("{name}")]
        public IActionResult UpdateReminder(string name, [FromBody] ReminderViewModel reminder)
        {
            if (reminder == null)
                return BadRequest("Reminder data is required");

            var updatedReminder = new Reminder
            {
                Name = reminder.Name,
                Date = reminder.Date,
                Day = reminder.Day,
                Time = reminder.Time
            };

            appService.UpdateReminder(name, updatedReminder);

            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult DeleteReminder(string name)
        {
            var existingReminder = appService.ViewReminder(name);

            if(existingReminder == null)
            {
                return NotFound();
            }

            appService.DeleteReminder(name);

            return NoContent();
        }

    }
}