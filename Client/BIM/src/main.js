import './style.css';
import { createApp } from 'vue';
import App from './App.vue';
import Toast from 'vue-toastification';
import 'vue-toastification/dist/index.css'; // Import Toast CSS

import { createRouter, createWebHistory } from 'vue-router';
import axios from 'axios';
import HomePage from './views/HomePage.vue';
import SignInPage from './views/SignInPage.vue';
import SignUpPage from './views/SignUpPage.vue';
import vuetify from './plugins/vuetify';
import AboutPage from './views/AboutPage.vue';
import BooksPage from './views/BookPage.vue';


axios.defaults.headers.common['Content-Type'] = 'application/json';
axios.defaults.headers.common['Accept'] = 'application/json';
axios.defaults.baseURL = 'https://localhost:7209'; 


const routes = [
    { path: '/', component: HomePage },
    { path: '/login', component: SignInPage },
    { path: '/signup', component: SignUpPage },
    { path: '/about', component: AboutPage },
    { path: '/books', component: BooksPage },
];


const router = createRouter({
  history: createWebHistory(),
  routes,
});


router.beforeEach((to, from, next) => {
  const isAuthenticated = localStorage.getItem('jwt_token'); 
  if (to.matched.some(record => record.meta.requiresAuth) && !isAuthenticated) {
    next('/login'); 
  } else {
    next();
  }
});


const app = createApp(App);  
app.use(vuetify);
app.use(router);  
app.mount('#app');

