<template>
  <div class="flex flex-col min-h-screen">
    <Header :isLoggedIn="isLoggedIn" @logout="handleLogout" />
    <main class="flex-grow">
      <router-view />
    </main>
    <Footer />
  </div>
</template>

<script>
import { ref } from "vue";
import { useRouter } from "vue-router";
import Header from './components/Header.vue';
import Footer from './components/Footer.vue';
import { RouterView } from 'vue-router';

export default {
  components: {
    Header,
    RouterView,
    Footer,
  },
  setup() {
    const router = useRouter(); // Get router instance
    const isLoggedIn = ref(!!localStorage.getItem("jwt_token"));

    const handleLogout = () => {
      localStorage.removeItem("jwt_token");
      isLoggedIn.value = false; // Update the state
      router.push("/"); // Redirect to Home page
    };

    return {
      isLoggedIn,
      handleLogout,
    };
  },
};
</script>
