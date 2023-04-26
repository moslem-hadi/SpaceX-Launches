const NextLaunchComponent = () => {
  return (
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
  );
};
export default NextLaunchComponent;
