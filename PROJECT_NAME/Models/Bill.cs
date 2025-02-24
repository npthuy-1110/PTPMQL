using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;
namespace PROJECT_NAME.Models
{
    public class Bill
    {
     public int Quantity {get; set;}
     public double UnitPrice {get; set;}
     public double TotalAmount {get; set;}
    }
}