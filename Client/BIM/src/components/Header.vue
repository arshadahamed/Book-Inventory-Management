<template>
  <header>
    <nav class="bg-white border-gray-200 px-4 lg:px-6 py-5 dark:bg-gray-800">
      <div class="flex flex-wrap justify-between items-center mx-auto max-w-screen-xl">
        <a href="/" class="flex items-center">
          <img src="/src/assets/logo/bim.png" class="mr-3 h-10" alt="BIM Logo" />
        </a>
        <div class="flex items-center lg:order-2">
          <template v-if="!isLoggedIn">
            <a
              href="/login"
              class="text-black hover:bg-red-500 focus:ring-4 font-bold rounded-lg text-sm px-4 lg:px-5 py-2 mr-2"
            >
              Login
            </a>
            <a
              href="/signup"
              class="text-white bg-red-700 hover:bg-black focus:ring-4 font-bold rounded-lg text-sm px-4 lg:px-5 py-2 mr-2"
            >
              Register
            </a>
          </template>
          <template v-else>
            <button
              @click="logout"
              class="bg-red-700 text-white rounded-lg px-4 py-2 hover:scale-105 duration-300"
            >
              Logout
            </button>
          </template>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: "Header",
  data() {
    return {
      isLoggedIn: !!localStorage.getItem("jwt_token"), // Initial check
    };
  },
  watch: {
    // Watch for changes in localStorage or login status
    isLoggedIn(newValue) {
      console.log("Login status changed:", newValue);
    },
  },
  methods: {
    logout() {
      localStorage.removeItem("jwt_token"); // Remove the token
      this.isLoggedIn = false; // Update the state
      this.$router.push("/login"); // Redirect to login page
    },
  },
  created() {
    // Listen for changes in login state
    window.addEventListener("storage", this.syncLoginState);
  },
  destroyed() {
    // Cleanup the listener
    window.removeEventListener("storage", this.syncLoginState);
  },
  methods: {
    syncLoginState() {
      this.isLoggedIn = !!localStorage.getItem("jwt_token");
    },
    logout() {
      localStorage.removeItem("jwt_token");
      this.syncLoginState(); // Update state
      this.$router.push("/login");
    },
  },
};
</script>
