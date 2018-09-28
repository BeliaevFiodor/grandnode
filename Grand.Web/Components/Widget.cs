﻿using Microsoft.AspNetCore.Mvc;
using Grand.Web.Services;
using System.Linq;
using Grand.Framework.Components;

namespace Grand.Web.ViewComponents
{
    public class WidgetViewComponent : BaseViewComponent
    {
        private readonly IWidgetViewModelService _widgetViewModelService;

        public WidgetViewComponent(IWidgetViewModelService widgetViewModelService)
        {
            this._widgetViewModelService = widgetViewModelService;
        }

        public IViewComponentResult Invoke(string widgetZone, object additionalData = null)
        {
            var model = _widgetViewModelService.PrepareRenderWidget(widgetZone, additionalData);

            if (!model.Any())
                return Content("");

            return View(model);
        }
    }
}