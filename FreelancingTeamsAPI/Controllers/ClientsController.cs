using Microsoft.AspNetCore.Mvc;
using FreelancingTeamData.Models;
using FreelancingTeamData.Reopsitories;
using FreelancingTeamData.Interfaces;
namespace FreelancingTeamsAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController:ControllerBase
{
    private readonly IClient<Client> _client;
    private readonly IProject<Project> _project;
    private readonly ITransaction<Transaction, ProjectPayment> _transaction;


    //public ClientsController(IClient<Client> client)
    //{
    //    _client = client;
    //}


    public ClientsController(IClient<Client> client, IProject<Project> project, ITransaction<Transaction, ProjectPayment> transaction)
    {
        _client = client;
        _project = project;
        _transaction = transaction;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Complain>>> GetComplains()
    {
        var obj = await _client.GetAll();
        if (obj != null)
        {
            return Ok(obj);
        }
        return NotFound();
    }

    //[HttpPost]
    //public async Task<ActionResult<Client>> PostClientAccount(Client client)
    //{
    //    if(client != null)
    //    {
    //        Client c = await _client.Create(client);
    //        if (c!= null)
    //            return Ok(c);
    //        return NotFound();
    //    }
    //    return BadRequest();

    //}

    //[HttpPost("login")]

    //public async Task <ActionResult<Client>> Login(string email, string password)
    //{
    //    if(email != null && password != null)
    //    {
    //        Client client = await _client.Login(email, password);
    //        if (client != null)
    //            return Ok(client);
    //        return NotFound();
    //    }
    //    return BadRequest();
    //}

    //[HttpPost("createproject")]
    //public async Task<ActionResult<Project>> CreateProject(Project project)
    //{
    //    if(project != null)
    //    {
    //        //Project p = await _project.PostProject(project);
    //        //if (p != null)
    //        //    return Ok(p);
    //    }
    //    return BadRequest();
    //}

    //[HttpPost("Pay")]
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


}
