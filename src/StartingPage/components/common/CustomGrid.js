import React from "react";
import Grid from "@mui/material/Grid";

const CustomGrid = () => (
  <Grid container spacing={0}>
    {Array.from({ length: 10 }, (_, i) => (
      <Grid item xs={0} key={i}>
        {Array.from({ length: 10 }, (_, j) => (
          <div
            style={{
              height: 40,
              width: 40,
              color: "#283048",
              border: "solid 1px",
            }}
            key={j}
          />
        ))}
      </Grid>
    ))}
  </Grid>
);

export default CustomGrid;
