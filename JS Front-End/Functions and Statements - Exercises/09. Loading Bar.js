function printLoadingBar(percentage) {
  count = percentage / 10;
  console.log(
    count === 10
      ? "100% Complete!"
      : `${percentage}% [${"%".repeat(count)}${".".repeat(
          10 - count
        )}]\nStill loading...`
  );
}
