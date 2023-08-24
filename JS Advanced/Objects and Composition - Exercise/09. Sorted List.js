function createSortedList() {
  return {
    list: [],
    sort: function () {
      this.list.sort((a, b) => a - b);
    },
    add: function (element) {
      this.list.push(element);
      this.size++;
      this.sort();
    },
    remove: function (index) {
      if (index >= 0 && index < this.list.length) {
        this.list.splice(index, 1);
        this.size--;
        this.sort();
      }
    },
    get: function (index) {
      if (index >= 0 && index < this.list.length) {
        return this.list[index];
      }
    },
    size: 0,
  };
}
