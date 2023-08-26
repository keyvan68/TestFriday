using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Entities;

public  class Product
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int Price { get; set; }

    public string Description { get; set; } = null!;


    public int NumberofProducts { get; set; }



}
