import { createApp } from 'vue';
import App from './App.vue';
import { createRouter, createWebHistory } from 'vue-router';
import axios from 'axios';
import HomePage from './views/HomePage.vue';
import SignInPage from './views/SignInPage.vue';
import SignUpPage from './views/SignUpPage.vue';
import BooksPage from './views/BookPage.vue';
import Toast, { POSITION } from "vue-toastification";
import "vue-toastification/dist/index.css";

// Configure Axios defaults
axios.defaults.headers.common['Content-Type'] = 'application/json';
axios.defaults.headers.common['Accept'] = 'application/json';
axios.defaults.baseURL = 'https://localhost:7209'; 

// Define routes
const routes = [
  { path: '/', component: HomePage },
  { path: '/login', component: SignInPage },
  { path: '/signup', component: SignUpPage },
  { path: '/books', component: BooksPage, meta: { requiresAuth: true } },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

// Navigation guards
router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem('jwt_token');

  if (to.path === '/login' && isAuthenticated) {
    next('/books');
  } else if (to.matched.some(record => record.meta.requiresAuth) && !isAuthenticated) {
    next('/login');
  } else {
    next();
  }
});

// Create Vue app
const app = createApp(App);

// Add toast notifications
app.use(Toast, {
  position: POSITION.TOP_RIGHT,
  timeout: 3000,
  closeButton: false,
  pauseOnHover: true,
});

// Use router
app.use(router);

// Mount the app
app.mount('#app');
