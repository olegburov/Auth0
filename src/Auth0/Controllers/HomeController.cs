﻿using Auth0.Data;
using Auth0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Auth0.Controllers
{
  public class HomeController : Controller
  {
    private readonly AppDbContext appContext;

    public HomeController(AppDbContext context)
    {
      this.appContext = context;
    }

    public async Task<IActionResult> Index()
    {
      var repositoriesList = await this.appContext.Repositories.AsNoTracking().ToListAsync();
      return View(repositoriesList);
    }

    [HttpGet]
    public IActionResult New()
    {
      return View();
    }

    [HttpPost]
    public IActionResult New(RepositoryModel repository)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      this.appContext.Add(repository);
      this.appContext.SaveChangesAsync();

      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
      var repository = await this.appContext.Repositories.FindAsync(id);

      if (repository == null)
      {
        return RedirectToAction("Index");
      }
      
      return View(repository);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(RepositoryModel repository)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      this.appContext.Attach(repository).State = EntityState.Modified;
      await this.appContext.SaveChangesAsync();

      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
      var repository = await this.appContext.Repositories.FindAsync(id);

      if (repository != null)
      {
        this.appContext.Remove(repository);
        await this.appContext.SaveChangesAsync();
      }

      return RedirectToAction("Index");
    }

    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}