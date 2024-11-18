using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanSync.Models;
public class BanModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Reason { get; set; } = null!;
    public string Location { get; set; } = null!;
}
