using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Data;
using FreelancingTeamData.Interfaces;
using FreelancingTeamData.Models;

namespace FreelancingTeamsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransaction<Transaction, ProjectPayment> _transaction;
        public TransactionsController(ITransaction<Transaction, ProjectPayment> transaction)
        {
            _transaction = transaction;
        }

        // There is a problem
        //[HttpPost]
        //public async Task<ActionResult<Transaction>> PayForProject(Transaction _object, int clientId, int projectId)
        ////public async Task<ActionResult<int>> PayForProject(Transaction _object, int clientId, int projectId)
        //{
        //    if (_object != null)
        //    {
        //        Transaction transaction = await _transaction.ProjectPayment(_object, clientId, projectId);
        //        if (transaction != null)
        //            // The problem in returned object.
        //            return Ok(transaction);
        //        return BadRequest();
        //    }
        //    return NotFound();
        //}

        [HttpPost("PayForProject")]
        public async Task<ActionResult<Transaction>> PayForProject(Transaction t)
        {
            if (t != null)
            {
                Transaction transaction = await _transaction.ProjectPayment(t);
                if (transaction != null)
                    // The problem in returned object.
                    return Ok(transaction);
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPut("RefundedMony")]
        public async Task<ActionResult<ProjectPayment>> RefundedMony(ProjectPayment pp)
        {
            if (pp != null && pp.RefundedMoney > 0 && pp.TransferredMoney == 0)
            {
                ProjectPayment projectPayment = await _transaction.RefundedMony(pp);
                if (projectPayment != null)
                    return Ok(projectPayment);
                return BadRequest();
            }
            return BadRequest();
        }


        [HttpPut("TransferredMoney")]
        public async Task<ActionResult<ProjectPayment>> TransferredMoney(ProjectPayment pp)
        //public async Task<ActionResult<int>> PayForProject(Transaction _object, int clientId, int projectId)
        {
            if (pp != null && pp.RefundedMoney == 0 && pp.TransferredMoney > 0)
            {
                ProjectPayment projectPayment = await _transaction.TransferredMoney(pp);
                if (projectPayment != null)
                    return Ok(projectPayment);
                return BadRequest();
            }
            return BadRequest();
        }


    }
}
