function dictionary(props) {
  props = props
    .map((str) => JSON.parse(str))
    .reduce((acc, curr) => {
      return {
        ...acc,
        ...curr,
      };
    }, {});

  Object.entries(props)
    .sort()
    .forEach(([key, value]) =>
      console.log(`Term: ${key} => Definition: ${value}`)
    );
}
