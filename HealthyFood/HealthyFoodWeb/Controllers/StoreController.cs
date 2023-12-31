﻿using Data.Interface.Models;
using HealthyFoodWeb.Models;
using HealthyFoodWeb.Models.Store;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthyFoodWeb.Controllers
{
    public class StoreController : Controller
    {
        private ICartService _cartService;
        private IUserService _userService;
        private IAuthService _authService;
        private IStoreCatalogueService _storeCatalogueService;

        public StoreController(ICartService cartService, IUserService userService, IAuthService authService, IStoreCatalogueService storeCatalogueService)
        {
            _userService = userService;
            _authService = authService;
            _cartService = cartService;
            _storeCatalogueService = storeCatalogueService;
        }

        public IActionResult storePageCatalogue(int page = 1, int perPage = 10)
        {
            var viewModel = _storeCatalogueService.CreateStoreViewModel(page, perPage);

            return View(viewModel);
        }

        public IActionResult CartPage()
        {
            var viewModel = new CartIndexViewModel();

            viewModel.Product = _cartService.
                GetCustomerProduct().
                Select(x => new CartViewModel
                {
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

            return View(viewModel);
        }

        public IActionResult DeleteFromCart(string name)
        {
            _cartService.DeleteFromCart(name);
            return RedirectToAction("CartPage");
        }


        [HttpGet]
        public IActionResult AddProductInBase()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProductInBase(CartViewModel viewModel)
        {
            _cartService.AddProductInBase(viewModel);
            return RedirectToAction("CartPage");
        }


        [HttpGet]
        public IActionResult AddProductInCatalogue()
        {
            var manufacturers = _storeCatalogueService
                .GetAllManufacturers();
            var viewModel = new StoreItemViewModel
            {
                AllManufacturers = manufacturers.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name,
                })
                .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddProductInCatalogue(StoreItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var manufacturers = _storeCatalogueService
                .GetAllManufacturers();
                viewModel.AllManufacturers = manufacturers.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name,
                })
                    .ToList();
                return View(viewModel);
            }
            _storeCatalogueService.AddStoreItem(viewModel);
            return RedirectToAction("storePageCatalogue");
        }

    }
}
