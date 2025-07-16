import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    host: '0.0.0.0',  // Добавьте эту строку!
    port: 5173,       // Используйте стандартный порт Vite
    proxy: {
      '/api': {
        target: 'http://famiry:8080',
        changeOrigin: true,
        rewrite: (path) => path
      }
    }
  }
})