# Use the official BusyBox image as a parent image
FROM busybox:latest

# Copy the script into the container
COPY run.sh /run.sh

# Give execution permissions to the script
RUN chmod +x /run.sh

# Run the script
CMD ["/run.sh"]