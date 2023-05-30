import { createRouter, createWebHistory } from 'vue-router'
import AppbarSection from "../views/AppbarSection.vue"
import BottomBannerSection from "../views/BottomBannerSection.vue"
import FooterSection from "../views/FooterSection.vue"
import HeadlinesSection from "../views/HeadlinesSection.vue"
import MainSection from "../views/MainSection.vue"
import SecondaryBannerSection from "../views/SecondaryBannerSection.vue"
import SlideshowSection from "../views/SlideshowSection.vue"

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: AppbarSection
    },
    {
      path: '/app-bar',
      name: 'app bar',
      component: AppbarSection
    },
    {
      path: '/bottom-banner',
      name: 'bottom banner',
      component: BottomBannerSection
    },
    {
      path: '/footer',
      name: 'footer',
      component: FooterSection
    },
    {
      path: '/headlines',
      name: 'headlines',
      component: HeadlinesSection
    },
    {
      path: '/main',
      name: 'main',
      component: MainSection
    },
    {
      path: '/secondary-banner',
      name: 'secondary banner',
      component: SecondaryBannerSection
    },
    {
      path: '/slideshow',
      name: 'slideshow',
      component: SlideshowSection
    },
  ]
})

export default router
