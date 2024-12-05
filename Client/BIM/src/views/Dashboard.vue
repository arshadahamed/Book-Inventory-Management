<template>
  <v-app class="bg-gray-100">
    <v-navigation-drawer app class="bg-blue-800 text-white">
      <!-- Sidebar content -->
      <v-list dense>
        <v-list-item-group v-if="!isMobile">
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title class="text-lg font-semibold"
                >Dashboard</v-list-item-title
              >
            </v-list-item-content>
          </v-list-item>
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title class="hover:text-gray-300 transition-colors"
                >Books</v-list-item-title
              >
              <v-list-item-subtitle class="text-gray-400"
                >CRUD Operations</v-list-item-subtitle
              >
            </v-list-item-content>
          </v-list-item>
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title class="hover:text-gray-300 transition-colors"
                >Role Assign</v-list-item-title
              >
            </v-list-item-content>
          </v-list-item>
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title class="hover:text-gray-300 transition-colors"
                >Role Add</v-list-item-title
              >
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app class="bg-blue-800 text-white shadow-lg">
      <v-toolbar-title>Dashboard</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>mdi-account-circle</v-icon>
        <span>{{ userEmail }}</span>
      </v-btn>
      <v-btn icon @click="logout">
        <v-icon>mdi-logout</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <!-- Book Details Table -->
      <v-container fluid class="px-6 py-4">
        <v-row>
          <v-col cols="12" md="12">
            <v-text-field
              v-model="searchQuery"
              label="Search Books"
              append-icon="mdi-magnify"
              single-line
              clearable
              class="mb-4 border-2 border-gray-300 rounded-lg shadow-sm"
            />
            <v-btn
              @click="searchBooks"
              class="bg-blue-600 text-white px-4 py-2 rounded-md hover:bg-blue-700 transition-colors mb-4"
            >
              Search
            </v-btn>
            <v-data-table
              :headers="bookHeaders"
              :items="books"
              item-key="id"
              :search="searchQuery"
              class="elevation-2 rounded-lg shadow-md"
            >
              <template v-slot:item.actions="{ item }">
                <v-btn
                  @click="editBook(item)"
                  icon
                  class="bg-yellow-500 text-white hover:bg-yellow-600 transition-colors"
                >
                  <v-icon>mdi-pencil</v-icon>
                </v-btn>
                <v-btn
                  @click="deleteBook(item)"
                  icon
                  class="bg-red-500 text-white hover:bg-red-600 transition-colors"
                >
                  <v-icon>mdi-delete</v-icon>
                </v-btn>
              </template>
            </v-data-table>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import axios from "axios";

export default {
  name: "Dashboard",
  data() {
    return {
      userEmail: "user@example.com", // You can fetch this from the session or store
      isMobile: false, // Check screen size
      searchQuery: "",
      books: [], // Dynamically fetched books
      bookHeaders: [
        { text: "Title", value: "title" },
        { text: "Author", value: "author" },
        { text: "Actions", value: "actions", sortable: false },
      ],
    };
  },
  created() {
    this.fetchBooks(); // Fetch books when the component is created
  },
  methods: {
    logout() {
      localStorage.removeItem("jwt_token");
      this.$router.push("/login");
    },

    async fetchBooks() {
      try {
        const response = await axios.get("https://localhost:7209/api/books", {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("jwt_token")}`,
          },
        });
        this.books = response.data;
      } catch (error) {
        console.error("Error fetching books:", error);
      }
    },

    async searchBooks() {
      try {
        const response = await axios.get(
          "https://localhost:7209/api/books/search",
          {
            params: {
              keywords: this.searchQuery,
            },
            headers: {
              Authorization: `Bearer ${localStorage.getItem("jwt_token")}`,
            },
          }
        );
        this.books = response.data;
      } catch (error) {
        console.error("Error searching books:", error);
      }
    },

    async editBook(book) {
      try {
        const updatedBook = { ...book, title: "Updated Title" }; // Modify as needed
        await axios.patch(
          `https://localhost:7209/api/books/${book.id}`,
          updatedBook,
          {
            headers: {
              Authorization: `Bearer ${localStorage.getItem("jwt_token")}`,
            },
          }
        );
        this.fetchBooks(); // Refresh the book list
      } catch (error) {
        console.error("Error editing book:", error);
      }
    },

    async deleteBook(book) {
      try {
        await axios.delete(`https://localhost:7209/api/books/${book.id}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem("jwt_token")}`,
          },
        });
        this.fetchBooks(); // Refresh the book list
      } catch (error) {
        console.error("Error deleting book:", error);
      }
    },
  },
};
</script>

<style scoped>

</style>
