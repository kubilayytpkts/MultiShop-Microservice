﻿namespace MultiShop.Catalog.Dtos.FeatureSlider
{
    public class UpdateFeatureSliderDto
    {
        public string SliderID { get; set; }
        public string SliderTitle { get; set; }
        public string SliderDescription { get; set; }
        public string SliderImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
