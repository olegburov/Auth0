﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OneGit.Web
{
  public class RepositoryModel
  {
    public Guid Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; }

    [StringLength(256)]
    public string Description { get; set; }

    [Required, StringLength(100)]
    public string Url { get; set; }
  }
}