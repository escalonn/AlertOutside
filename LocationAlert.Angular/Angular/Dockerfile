FROM node:8
WORKDIR /app

# copy manifest and install as distinct layers
COPY package*.json ./
RUN npm install

# copy everything else
COPY . ./

CMD ["npm", "start"]
