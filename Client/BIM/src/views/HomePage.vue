<template>
  <div class="bg-gradient-to-r from-red-50 to-cyan-50 flex flex-row min-h-screen">
    <div class="relative isolate px-6 pt-14 lg:px-8 flex-grow">
      <div class="mx-auto max-w-2xl py-32 sm:py-48 lg:py-56">
        <div class="text-center">
          <h1
            class="text-balance text-5xl font-semibold tracking-tight text-gray-900 sm:text-7xl"
          >
            Effortlessly Manage Your Book Inventory
          </h1>
          <p
            class="mt-8 text-pretty text-lg font-medium text-gray-500 sm:text-xl/8"
          >
            Track, organize, and optimize your book collection with ease. From
            cataloging to stock management, streamline your inventory and ensure
            every book is accounted for.
          </p>
          <div class="mt-10 flex items-center justify-center gap-x-6">
            <a
              href="#"
              class="rounded-md bg-red-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-black focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >Get started</a
            >
            <a href="#" class="text-sm/6 font-semibold text-gray-900"
              >Learn more <span aria-hidden="true">→</span></a
            >
          </div>
        </div>
      </div>
      <div
        class="absolute inset-x-0 top-[calc(100%-13rem)] -z-10 transform-gpu overflow-hidden blur-3xl sm:top-[calc(100%-30rem)]"
        aria-hidden="true"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  methods: {},
};
</script>
