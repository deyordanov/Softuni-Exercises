# Base the dockerfile on the official node image
FROM node

# Set the working directory in the docker container
WORKDIR /app

# Copy all files starting with 'package' and having the extension '.json' inside the working directory
COPY package*.json .

# Install all dependencies
RUN npm install

# Copy the rest of the application files (done seperately from dependency installing in order to)
# take advantage of caching
COPY . .

# Set the port to expose
EXPOSE 80

# Set the command that will be run after the container is created (it can be overwritter)
CMD ["npm", "start"]