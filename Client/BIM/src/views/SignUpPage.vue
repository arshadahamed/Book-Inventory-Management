<template>
  <section class="bg-gray-50 h-[80vh] flex items-center justify-center">
    <div
      class="bg-gray-100 flex rounded-2xl shadow-lg max-w-3xl p-5 items-center"
    >
      <!-- form -->
      <div class="md:w-1/2 px-8 md:px-16">
        <h2 class="font-bold text-2xl text-[#002D74]">Sign Up</h2>
        <p class="text-xs mt-4 text-[#002D74]">Please Register Here!</p>

        <form @submit.prevent="handleSubmit" class="flex flex-col gap-4">
          <input
            class="p-2 mt-8 rounded-xl border"
            type="text"
            name="username"
            v-model="username"
            placeholder="Username"
            required
          />
          <input
            class="p-2 rounded-xl border"
            type="email"
            name="email"
            v-model="email"
            placeholder="Email"
            required
          />
          <div class="relative">
            <input
              class="p-2 rounded-xl border w-full"
              :type="passwordVisible ? 'text' : 'password'"
              name="password"
              v-model="password"
              placeholder="Password"
              required
            />
            <svg
              @click="togglePassword"
              xmlns="http://www.w3.org/2000/svg"
              width="16"
              height="16"
              fill="gray"
              class="bi bi-eye absolute top-1/2 right-3 -translate-y-1/2 cursor-pointer"
              viewBox="0 0 16 16"
            >
              <path
                d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z"
              />
              <path
                d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z"
              />
            </svg>
          </div>
          <button
            class="bg-[#a72525] rounded-xl text-white py-2 hover:scale-105 duration-300"
            type="submit"
          >
            Register
          </button>
        </form>

        <div class="mt-6 grid grid-cols-3 items-center text-gray-400">
          <hr class="border-gray-400" />
          <p class="text-center text-sm">OR</p>
          <hr class="border-gray-400" />
        </div>

        <div
          class="mt-3 text-xs flex justify-between items-center text-[#002D74]"
        >
          <p>Already have an account?</p>
          <button
            type="submit"
            class="py-2 px-5 bg-white border rounded-xl hover:scale-110 duration-300"
          >
            <a href="/login">Login</a>
          </button>
        </div>
      </div>

      <!-- Image -->
      <div class="md:block hidden w-1/2">
        <img
          class="rounded-2xl"
          src="../assets/logo/Books.jpg"
        />
      </div>
    </div>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "SignUpPage",
  data() {
    return {
      username: "",
      email: "",
      password: "",
      passwordVisible: false,
    };
  },
  methods: {
  async handleSubmit() {
    try {
      const response = await axios.post(
        'https://localhost:7209/api/account/register',
        {
          username: this.username,
          email: this.email,
          password: this.password,
        }
      );
      console.log('Registration successful:', response.data);

      // Check if the toast plugin is available
      if (this.$toast) {
        this.$toast.success(response.data.message);  // Show success toast
      } else {
        console.error('Toast is not available');
      }

      // Redirect to the Home page after successful registration
      this.$router.push('/login');
    } catch (error) {
      console.error('Registration failed:', error);

      // Check if the toast plugin is available for errors
      if (this.$toast) {
        this.$toast.error('Registration failed! Please try again.');  // Show error toast
      } else {
        console.error('Toast is not available');
      }
    }
  }
}
,
};
</script>
