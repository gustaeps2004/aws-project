import { createRouter, createWebHistory  } from 'vue-router'
import Login from '@/views/Login'
import RequestMfa from '@/views/RequestMfa'

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/request-mfa',
    name: 'RequestMFA',
    component: RequestMfa
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
