using Infrasturcure.Data;
using Microsoft.AspNetCore.Mvc;
using Skinet.Errors;

namespace Skinet.Controllers;

public class BuggyController : BaseApiController
{
    private readonly StoreContext _context;

    public BuggyController(StoreContext context)
    {
        _context = context;
    }
    [HttpGet("notfound")]
    public  ActionResult GetNotFound( )
    {
        return NotFound(new ApiResponse(404));
    }
    [HttpGet("servererror")]
    public  ActionResult GetServerError( )
    {
        int.Parse("djjd");
        return NotFound();
    }
    [HttpGet("badRequest")]
    public  ActionResult GetBadRequest( )
    {
        return BadRequest(new ApiResponse(400));
    }
    [HttpGet("bad/{id}")]
    public  ActionResult GetBadRequest2(int id)
    {
        return Ok();
    }



}