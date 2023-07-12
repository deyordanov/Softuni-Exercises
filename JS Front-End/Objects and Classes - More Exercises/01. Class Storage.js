class Storage {
  constructor(capacity) {
    this.capacity = capacity;
    this.storage = [];
    this.totalCost = 0;
  }

  addProduct(product) {
    this.capacity -= product.quantity;
    this.storage.push(product);
    this.totalCost += product.price * product.quantity;
  }

  getProducts() {
    return this.storage.map((item) => JSON.stringify(item)).join("\n");
  }
}
