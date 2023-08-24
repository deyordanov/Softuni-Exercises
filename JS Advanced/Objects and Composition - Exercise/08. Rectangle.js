function rectangle(width, height, color) {
  return {
    width,
    height,
    color: color.substring(0, 1).toUpperCase() + color.substring(1),
    calcArea: function () {
      return this.width * this.height;
    },
  };
}
