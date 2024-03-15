using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStoragePratic.Domain.Entities;
public class User
{

    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string AcessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

}
