import React from "react";
import { connect } from "unistore/react";
import { reducer } from "../../store/init";
import { Trans } from "react-i18next";

// The connect() function from unistore help to connect the store state (from /store/init.js)
// and notify the change to the component once the state is modified.
// For more information, visit: https://github.com/developit/unistore
const Counter = connect(
  "count",
  reducer
)(({ count, increaseCount }) => {
  return (
    <div>
      <p>
        <Trans count={count}>Current {{ count }}</Trans>
      </p>
      {/* If the button is clicked, invoke the increaseCount function. This function is injected by the connect() function, and from the reducer object */}
      <button onClick={increaseCount}>
        <Trans>Click to increase</Trans>
      </button>
    </div>
  );
});

export default Counter;
