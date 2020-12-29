using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarServiceApp_backend.Models
{
public class User
{
    public User(Request request)
    {
        var check = new EmailAddressAttribute();
        if(check.IsValid(request.email))
               this.Email = request.email;
        else
            {
               new ExceptionWrongEmail("Invalid email");
            }
        this.Password = request.password;
        this.Name = request.name;
        _idCount = _idCount+1;
        this.Id = _idCount;
        this.Role = (int)UsersRoleEnum.Client;
    }
    public User()
    {
        _idCount = _idCount+1;
        this.Id = _idCount;
    }
    //{this.Email = _user.Email;  this.Id = _user.Id;     this.Name = _user.Name;     this.Role = _user.Role; this.Password = _user.Password; }
    [Key]
    public int Id{get; set;}
    [Required]
    public string Name{get; set;}
    [Required][EmailAddress]
    public string Email{get; set;}
    [Required]
    public string Password{get; set;}
    [Required]
    public int Role{get; set;}
    [ForeignKey("Role")]
    public UsersRole OfRole{get; set;}

    [NotMapped]
    private static int _idCount;
    [NotMapped]
    
    public class Request
    {
        public string name{get; set;}
        public string email{get;set;}
        public string password{get; set;}
    }  
   
}
public class UsersRole
{
    [Key]
    public int Id {get; set;}    
    public string Name {get; set;}   
}

public enum UsersRoleEnum
{
    Admin = 0,
    Client = 1,
    Mechanic = 2
}
class ExceptionWrongEmail: Exception
{
public ExceptionWrongEmail(string mess): base(mess)
{}
}
}
