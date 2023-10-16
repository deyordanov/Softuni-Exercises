export default function NavTabs() {
  return (
    <ul className="nav nav-tabs" role="tablist">
      <li role="presentation" className="active">
        <a href="#day-1" aria-controls="home" role="tab" data-toggle="tab">
          Day 01{" "}
          <small className="hidden-xs">
            (20<sup>th</sup>, October)
          </small>
        </a>
      </li>
      <li role="presentation">
        <a href="#day-2" aria-controls="profile" role="tab" data-toggle="tab">
          Day 02{" "}
          <small className="hidden-xs">
            (21<sup>st</sup>, October)
          </small>
        </a>
      </li>
      <li role="presentation">
        <a href="#day-3" aria-controls="messages" role="tab" data-toggle="tab">
          Day 03{" "}
          <small className="hidden-xs">
            (22<sup>nd</sup>, October)
          </small>
        </a>
      </li>
    </ul>
  );
}
