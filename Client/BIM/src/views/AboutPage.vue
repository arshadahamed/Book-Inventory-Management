<template>
  <aside class="sidebar">
    <!-- sidebar close btn -->
    <button
      type="button"
      class="sidebar-close-btn text-gray-500 hover-text-white hover-bg-main-600 text-md w-24 h-24 border border-gray-100 hover-border-main-600 d-xl-none d-flex flex-center rounded-circle position-absolute"
    >
      <i class="ph ph-x"></i>
    </button>
    <!-- sidebar close btn -->

    <a
      href="/"
      class="h-14 w-auto text-center p-20 position-sticky inset-block-start-0 bg-white w-100 z-1 pb-10"
    >
      <img src="../assets/logo/bim.png" alt="Logo" />
    </a>

    <div class="sidebar-menu-wrapper overflow-y-auto scroll-sm">
      <div class="p-20 pt-10">
        <ul class="sidebar-menu">
          <li class="sidebar-menu__item">
            <a href="javascript:void(0)" class="sidebar-menu__link">
              <span class="icon"><i class="ph ph-squares-four"></i></span>
              <span class="text">Dashboard</span>
            </a>
          </li>

          <li class="sidebar-menu__item">
            <a href="library.html" class="sidebar-menu__link">
              <span class="icon"><i class="ph ph-books"></i></span>
              <span class="text">Books</span>
            </a>
          </li>
          <li class="sidebar-menu__item">
            <a href="students.html" class="sidebar-menu__link">
              <span class="icon"><i class="ph ph-users-three"></i></span>
              <span class="text">Users</span>
            </a>
          </li>

          <li class="sidebar-menu__item">
            <span
              class="text-gray-300 text-sm px-20 pt-20 fw-semibold border-top border-gray-100 d-block text-uppercase"
              >Settings</span
            >
          </li>
          <li class="sidebar-menu__item">
            <a href="setting.html" class="sidebar-menu__link">
              <span class="icon"><i class="ph ph-gear"></i></span>
              <span class="text">Account Settings</span>
            </a>
          </li>
        </ul>
      </div>
    </div>
  </aside>
  <!-- ============================ Sidebar End  ============================ -->

  <div class="dashboard-main-wrapper">
    <div class="top-navbar flex-between gap-16">
      <div class="flex-align gap-16">
        <!-- Toggle Button Start -->
        <button
          type="button"
          class="toggle-btn d-xl-none d-flex text-26 text-gray-500"
        >
          <i class="ph ph-list"></i>
        </button>
        <!-- Toggle Button End -->

        <form action="#" class="w-350 d-sm-block d-none">
          <div class="position-relative">
            <button
              type="submit"
              class="input-icon text-xl d-flex text-gray-100 pointer-event-none"
            >
              <i class="ph ph-magnifying-glass"></i>
            </button>
            <input
              type="text"
              class="form-control ps-40 h-40 border-transparent focus-border-main-600 bg-main-50 rounded-pill placeholder-15"
              placeholder="Search..."
            />
          </div>
        </form>
      </div>

      <div class="flex-align gap-16">
        <div class="">
          <h4 class="mb-0">Michel John</h4>
          <p class="fw-medium text-13 text-gray-200">examplemail@mail.com</p>
        </div>
        <a
          href="sign-in.html"
          class="py-12 text-15 px-20 hover-bg-danger-50 text-gray-300 hover-text-danger-600 rounded-8 flex-align gap-8 fw-medium text-15"
        >
          <span class="text-2xl text-danger-600 d-flex"
            ><i class="ph ph-sign-out"></i
          ></span>
          <span class="text">Log Out</span>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AboutPage",

  methods: {},
};
</script>
