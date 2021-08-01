const colors = require('tailwindcss/colors');
module.exports = {
  purge: [],
  darkMode: false,
  theme:[],
  purge: {
    enabled: true,
    content: [
        './**/*.html',
        './**/*.razor'
    ],
  },
  variants: {
    extend: {},
  },
  plugins: [],
}