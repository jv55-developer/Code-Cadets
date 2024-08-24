module.exports = (sequelize, DataTypes) => {
  const Work = sequelize.define(
    "work",
    {
      id: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true,
        allowNull: false,
      },
      user_id: {
        type: DataTypes.INTEGER,
        allowNull: false,
      },
      activity: {
        type: DataTypes.STRING,
        allowNull: false,
      },
      time: {
        type: DataTypes.STRING,
        allowNull: false,
      },
    },
    {
      createdAt: "date_entered",
      updatedAt: "date_updated",
    }
  );

  return Work;
};
