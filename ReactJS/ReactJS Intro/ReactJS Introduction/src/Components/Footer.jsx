export default function Footer() {
  return (
    <div className="container-fluid footer">
      <div className="row contact">
        <div className="col-md-6 contact-form">
          <h3 className="content-ct">
            <span className="ti-email"></span> Contact Form
          </h3>
          <form className="form-horizontal" data-toggle="validator" role="form">
            <div className="form-group">
              <label htmlFor="name" className="col-sm-3 control-label">
                Name<sup>*</sup>
              </label>
              <div className="col-sm-9">
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  placeholder="John Doe"
                  required
                />
                <div className="help-block with-errors pull-right"></div>
                <span
                  className="form-control-feedback"
                  aria-hidden="true"
                ></span>
              </div>
            </div>
            <div className="form-group">
              <label htmlFor="email" className="col-sm-3 control-label">
                Email<sup>*</sup>
              </label>
              <div className="col-sm-9">
                <input
                  type="email"
                  className="form-control"
                  id="email"
                  placeholder="you@youremail.com"
                  required
                />
                <div className="help-block with-errors pull-right"></div>
                <span
                  className="form-control-feedback"
                  aria-hidden="true"
                ></span>
              </div>
            </div>
            <div className="form-group">
              <label htmlFor="message" className="col-sm-3 control-label">
                Your Message<sup>*</sup>
              </label>
              <div className="col-sm-9">
                <textarea
                  id="message"
                  className="form-control"
                  rows="3"
                  required
                ></textarea>
                <div className="help-block with-errors pull-right"></div>
                <span
                  className="form-control-feedback"
                  aria-hidden="true"
                ></span>
              </div>
            </div>
            <div className="form-group">
              <div className="col-sm-offset-3 col-sm-9">
                <button
                  type="submit"
                  id="submit"
                  name="submit"
                  className="btn btn-yellow pull-right"
                >
                  Send <span className="ti-arrow-right"></span>
                </button>
              </div>
            </div>
          </form>
        </div>
        <div className="col-md-4 col-md-offset-1 content-ct">
          <h3>
            <span className="ti-twitter"></span> Twitter Feed
          </h3>
          <p>
            Lorem <a href="#">#Ipsum</a> is a dummy text used as a text filler
            in designs. This is just a dummy text. via{" "}
            <a href="#">@designerdada</a>{" "}
          </p>
          <hr />
          <p>
            Lorem Ipsum is a <a href="#">#dummy</a> text used as a text filler
            in designs. This is just a dummy text. via{" "}
            <a href="#">@designerdada</a>{" "}
          </p>
          <hr />
          <p>
            Lorem Ipsum is a <a href="#">#dummy</a> text used as a text filler
            in designs. This is just a dummy text. via{" "}
            <a href="#">@designerdada</a>{" "}
          </p>
        </div>
      </div>
      <div className="row footer-credit">
        <div className="col-md-6 col-sm-6">
          <p>
            &copy; 2015,{" "}
            <a href="http://www.designerdada.com">DesignerDada.com</a> | All
            rights reserved.
          </p>
        </div>
        <div className="col-md-6 col-sm-6">
          <ul className="footer-menu">
            <li>
              <a href="#">About Us</a>
            </li>
            <li>
              <a href="#">Privacy Policy</a>
            </li>
            <li>
              <a href="#">Terms &amp; Condition</a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  );
}
