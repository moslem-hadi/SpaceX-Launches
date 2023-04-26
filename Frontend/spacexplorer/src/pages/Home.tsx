const Home = () => {
  return (
    <>
      <main>
        <section className="upcoming" id="next-launch">
          <div className="container">
            <h1 id="headline">Next Launch</h1>
            <div id="countdown">
              <ul>
                <li>
                  <span id="days"></span>days
                </li>
                <li>
                  <span id="hours"></span>Hours
                </li>
                <li>
                  <span id="minutes"></span>Minutes
                </li>
                <li>
                  <span id="seconds"></span>Seconds
                </li>
              </ul>
            </div>
          </div>
        </section>

        <ul className="timeline">
          <li className="timeline-event">
            <div>
              <label className="timeline-event-icon"></label>
              <div className="timeline-event-copy">
                <p className="timeline-event-thumbnail">
                  2006-03-24 - FalconSat
                </p>
                <h3>Falcon 1 - Merlin A </h3>
                <h4>merlin engine failure</h4>
                <p>
                  <strong>Details</strong>
                  <br />
                  Engine failure at 33 seconds and loss of vehicle
                </p>
              </div>
            </div>
            <img
              alt=""
              className="flight-image"
              src="https://images2.imgbox.com/3c/0e/T8iJcSN3_o.png"
            />
          </li>

          <li className="timeline-event">
            <div>
              <label className="timeline-event-icon"></label>
              <div className="timeline-event-copy">
                <p className="timeline-event-thumbnail">2006-03-24 - DemoSat</p>
                <h3>Falcon 1 - Merlin A </h3>
                <h4>merlin engine failure</h4>
                <p>
                  <strong>Details</strong>
                  <br />
                  harmonic oscillation leading to premature engine shutdown
                </p>
              </div>
            </div>
            <img
              alt=""
              className="flight-image"
              src="https://images2.imgbox.com/4f/e3/I0lkuJ2e_o.png"
            />
          </li>

          <li className="timeline-event">
            <div>
              <label className="timeline-event-icon"></label>
              <div className="timeline-event-copy">
                <p className="timeline-event-thumbnail">
                  2006-03-24 - Trailblazer
                </p>
                <h3>Falcon 1 - Merlin A </h3>
                <h4>merlin engine failure</h4>
                <p>
                  <strong>Details</strong>
                  <br />
                  residual stage-1 thrust led to collision between stage 1 and
                  stage 2
                </p>
              </div>
            </div>
            <img
              alt=""
              className="flight-image"
              src="https://images2.imgbox.com/3d/86/cnu0pan8_o.png"
            />
          </li>
          <li className="timeline-event">
            <label className="timeline-event-icon"></label>
            <div className="timeline-event-copy">
              <p className="timeline-event-thumbnail">
                November 2009 - März 2011
              </p>
              <h3>Freelancer</h3>
              <h4>Designer und Autor</h4>
              <p>
                Konzeption, Design und Produktion von Digitalen Magazinen mit
                InDesign, der Adobe Digital Publishing Suite und HTML5.
                Co-Autorin der Fachbücher "Digitales Publizieren für Tablets"
                und "Adobe Digital Publishing Suite" erschienen im
                dpunkt.verlag.
              </p>
            </div>
          </li>
          <li className="timeline-event">
            <label className="timeline-event-icon"></label>
            <div className="timeline-event-copy">
              <p className="timeline-event-thumbnail">April 2011 - heute</p>
              <h3>konplan gmbh</h3>
              <h4>IT-Consultant</h4>
              <p>
                <strong>Systemarchitektur, Consulting</strong>
                <br />
                Konzeption und Modellierung von Systemen und APIs für Digital
                Publishing und Entitlement nach SOA
              </p>
            </div>
          </li>
        </ul>
      </main>
    </>
  );
};

export default Home;
