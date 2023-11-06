/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,js,mjs,ejs}"],
  theme: {
    extend: {},
  },
  corePlugins: {
    aspectRatio: false,
  },
  plugins: [
    require('@tailwindcss/forms'),
    require('@tailwindcss/aspect-ratio'),
  ],
}

