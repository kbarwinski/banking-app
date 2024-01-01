# BUILD
FROM node:20 as build
WORKDIR /app
COPY package.json package-lock.json .
RUN npm install
COPY . .
RUN npm run build --prod

# DEPLOY
FROM nginx:alpine as deploy
COPY --from=build /app/dist/banking-frontend /usr/share/nginx/html
EXPOSE 4200
