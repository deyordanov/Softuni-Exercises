function browse(browser, commands) {
  const browserName = browser["Browser Name"];
  delete browser["Browser Name"];
  commands.forEach((command) => {
    if (command === "Clear History and Cache") {
      Object.keys(browser).forEach((br) => (browser[br] = []));
    } else {
      const [type, site] = command.split(" ");
      if (type === "Open") {
        open(site, command);
      } else if (type === "Close") {
        close(site, command);
      }
    }
  });

  console.log(browserName);
  Object.keys(browser).forEach((br) =>
    console.log(`${br}: ${browser[br].join(", ")}`)
  );

  function open(site, command) {
    browser["Open Tabs"].push(site);
    logs(command);
  }

  function close(site, command) {
    if (browser["Open Tabs"].includes(site)) {
      const idx = browser["Open Tabs"].indexOf(site);
      browser["Open Tabs"].splice(idx, 1);
      browser["Recently Closed"].push(site);
      logs(command);
    }
  }

  function logs(command) {
    browser["Browser Logs"].push(command);
  }
}

browse(
  {
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": [
      "Open Gmail",
      "Close Gmail",
      "Open Dropbox",
      "Open YouTube",
      "Close Dropbox",
    ],
  },
  ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
