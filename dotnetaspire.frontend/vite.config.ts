import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
    plugins: [react()],
    server: {
        port: process.env.PORT ? parseInt(process.env.PORT, 10) : 3001,
    },
});

console.log("Webapi: ", process.env.VITE_WEBAPI, "Port: ", process.env.PORT);