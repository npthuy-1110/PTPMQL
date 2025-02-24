using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;
namespace PROJECT_NAME.Models;
public class Person
{
    public required string PersonId { get; set; }
    public required string FullName { get; set; }
    public required string Address { get; set; }
}