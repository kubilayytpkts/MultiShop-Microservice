﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
