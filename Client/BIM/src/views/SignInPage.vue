<template>
  <section class="bg-gray-50 h-[80vh] flex items-center justify-center">
    <!-- login container -->
    <div
      class="bg-gray-100 flex rounded-2xl shadow-lg max-w-3xl p-5 items-center"
    >
      <!-- form -->
      <div class="md:w-1/2 px-8 md:px-16">
        <h2 class="font-bold text-2xl text-[#002D74]">Login</h2>
        <p class="text-xs mt-4 text-[#002D74]">
          If you are already a member, easily log in
        </p>

        <form @submit.prevent="login" class="flex flex-col gap-4">
          <input
            v-model="email"
            class="p-2 mt-8 rounded-xl border"
            type="text"
            placeholder="Email"
            required
          />
          <div class="relative">
            <input
              v-model="password"
              class="p-2 rounded-xl border w-full"
              type="password"
              placeholder="Password"
              required
            />
          </div>
          <button
            type="submit"
            :disabled="loading"
            class="bg-[#a72525] rounded-xl text-white py-2 hover:scale-105 duration-300"
          >
            Login
          </button>
        </form>

        <!-- Validation Message -->
        <p v-if="message" class="text-red-500 text-xs mt-2">{{ message }}</p>

        <div class="mt-6 grid grid-cols-3 items-center text-gray-400">
          <hr class="border-gray-400" />
          <p class="text-center text-sm">OR</p>
          <hr class="border-gray-400" />
        </div>

        <button
          class="bg-white border py-2 w-full rounded-xl mt-5 flex justify-center items-center text-sm hover:scale-105 duration-300 text-[#002D74]"
          @click="loginWithGoogle"
        >
          <svg
            class="mr-3"
            xmlns="http://www.w3.org/2000/svg"
            viewBox="0 0 48 48"
            width="25px"
          >
            <path
              fill="#FFC107"
              d="M43.611,20.083H42V20H24v8h11.303c-1.649,4.657-6.08,8-11.303,8c-6.627,0-12-5.373-12-12c0-6.627,5.373-12,12-12c3.059,0,5.842,1.154,7.961,3.039l5.657-5.657C34.046,6.053,29.268,4,24,4C12.955,4,4,12.955,4,24c0,11.045,8.955,20,20,20c11.045,0,20-8.955,20-20C44,22.659,43.862,21.35,43.611,20.083z"
            />
          </svg>
          Login with Google
        </button>

        <div class="mt-5 text-xs border-b border-[#002D74] py-4 text-[#002D74]">
          <a href="#">Forgot your password?</a>
        </div>

        <div
          class="mt-3 text-xs flex justify-between items-center text-[#002D74]"
        >
          <p>Don't have an account?</p>
          <button
            type="submit"
            class="py-2 px-5 bg-white border rounded-xl hover:scale-110 duration-300"
          >
            <a href="/signup">Register</a>
          </button>
        </div>
      </div>

      <!-- Image -->
      <div class="md:block hidden w-1/2">
        <img class="rounded-2xl" src="../assets/logo/Books.jpg" />
      </div>
    </div>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "SignInPage",
  data() {
    return {
      email: "", // Update email to username
      password: "",
      message: "",
      loading: false, // New loading flag
    };
  },
  methods: {
    async login() {
      if (!this.email || !this.password) {
        this.message = "Email and password are required.";
        return;
      }

      this.loading = true;
      try {
        const response = await axios.post(
          "https://localhost:7209/api/Account/Login",
          {
            email: this.email,
            password: this.password,
          }
        );

        if (response.data.token) {
          localStorage.setItem("jwt_token", response.data.token);
          this.$router.push("/");
        } else {
          this.message = "Invalid credentials.";
        }
      } catch (error) {
        console.error(error.response ? error.response.data : error);
        if (error.response && error.response.status === 401) {
          this.message = "Invalid credentials or unauthorized access.";
        } else {
          this.message = error.response
            ? error.response.data.message
            : "An error occurred.";
        }
      } finally {
        this.loading = false;
      }
    },
    loginWithGoogle() {
      // Google login logic here
      console.log("Login with Google clicked");
    },
  },
};
</script>

<style scoped></style>
