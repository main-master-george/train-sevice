FROM node:20-alpine AS build
WORKDIR /app
COPY train-service-client/package*.json ./
RUN npm install
COPY train-service-client ./
RUN npm run build

FROM nginx:1.25-alpine
COPY train-service-client/nginx.conf /etc/nginx/nginx.conf
COPY --from=build /app/dist /usr/share/nginx/html

EXPOSE 3000
CMD ["nginx", "-g", "daemon off;"]
