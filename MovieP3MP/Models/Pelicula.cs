﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace MovieP3MP.Modelos;

public class Pelicula
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string ActorPrincipal { get; set; }
    public string Premios { get; set; }
    public string SitioWeb { get; set; }
    public string MPillajo { get; set; }
}

