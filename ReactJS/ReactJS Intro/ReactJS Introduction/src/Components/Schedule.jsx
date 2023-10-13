import NavTabs from "./NavTabs";
import TabPanes from "./TabPanes";

export default function Schedule() {
  return (
    <div className="container">
      <div className="row me-row schedule" id="schedule">
        <h2 className="row-title content-ct">Event Schedule</h2>
        <div className="col-md-12">
          <NavTabs />

          <TabPanes />
        </div>
      </div>
    </div>
  );
}
